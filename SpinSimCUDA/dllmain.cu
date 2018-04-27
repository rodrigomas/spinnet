#include <stdio.h>
#include <stdlib.h>
#include <cuda.h>
#include <curand.h>

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <windows.h>

#define CUDA_CALL(x) do { if((x) != cudaSuccess) { \
printf("Error at %s:%d\n",__FILE__,__LINE__); \
return EXIT_FAILURE;}} while(0)
#define CURAND_CALL(x) do { if((x) != CURAND_STATUS_SUCCESS) { \
printf("Error at %s:%d\n",__FILE__,__LINE__); \
return EXIT_FAILURE;}} while(0)

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
					 )
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}


__device__ void load_neightbours(int i, int j, int lines, int cols, int* m, int* neighbours)
{
    // UP
    if (i == 0) neighbours[0] = m[((lines - 1) * lines + j)];
    else neighbours[0] = m[((i - 1) * lines + j)];

    //LEFT
    if (j == cols - 1) neighbours[1] = m[(i * lines + 0)];
    else neighbours[1] = m[(i * lines + j + 1)];

    // Down
    if (i == lines - 1) neighbours[2] = m[(0 + j)];
    else neighbours[2] = m[((i + 1) * lines + j)];

    //RIGHT
    if (j == 0) neighbours[3] = m[(i * lines + cols - 1)];
    else neighbours[3] = m[(i * lines + j - 1)];
}



// cuda kernel (internal)
__global__ void spin_simulate(int *m, float *r, unsigned int N, int nAtoms, float J, float T)
{
    unsigned int idx = blockIdx.x * blockDim.x + threadIdx.x; 

	if (idx < N)
	{
		// note1: no need for shared memory here
		// note2: global memory access is coalesced
		//        (no structs, float only used)

		// do computations M times on each thread
		// to extend processor time
		//for(unsigned int i = 0; i < M; i++)
		//{
		//	// some easy arithmetics		
		//	a[idx] = a[idx] * a[idx] * 0.1 - a[idx] - 10;
		//}

		float pr = r[idx];

		int p = (int)(pr * N); //Rnd.Next(0, size);//Position[i * nAtoms + j];

		int ii = p / nAtoms;
		int jj = p % nAtoms;

		int neighbours[4] = {1,1,-1,-1};

		load_neightbours(ii, jj, nAtoms, nAtoms, m, neighbours);

		double dE = 0;
		double E0 = 0;
		double Ef = 0;

		int Sum = 0;

		for (int k = 0; k < 4; k++)
		{
			Sum += m[p] * neighbours[k];
		}

		E0 = -(J / T) * Sum;
		Ef = (J / T) * Sum;

		dE = Ef - E0;

		if (dE < 0)
		{
			m[p] = -m[p];
		}
		else
		{
			//double E = Math.Exp(-dE / (K * T));
			float E =  expf(-dE / (T));

			float Z = (pr + r[p]) /2.0f;//Rnd.NextDouble();

			if (E >= Z)
			{
				m[p] = -m[p];
			}                            
		}
	}
}

// internal variable (example, not really necessary here)
//static volatile int PRINT_ERRORS = 1;	// true

// cuda wrapper function
extern "C" int __declspec(dllexport) __stdcall SpinSimulateGPU
	(
	int *m,						
	int N,				
	int nAtoms,			
	float J, float T,
	int Steps,
	const int cuBlockSize = 512
	)
{
	int *m_d;							// pointer to device array
	float *d_r;							// pointer to device array
    size_t size = N * sizeof(int);

	curandGenerator_t gen;

	CURAND_CALL(curandCreateGenerator(&gen, CURAND_RNG_PSEUDO_DEFAULT));
	CURAND_CALL(curandSetPseudoRandomGeneratorSeed(gen, 1234ULL));

	CUDA_CALL(cudaMalloc((void **)&d_r, N * sizeof(float)));	
   
    CUDA_CALL(cudaMalloc((void**)&m_d, size));		// allocate array on device    
	CUDA_CALL(cudaMemcpy(m_d, m, size, cudaMemcpyHostToDevice));
    
    int n_blocks = N / cuBlockSize + (N % cuBlockSize == 0 ? 0 : 1);

	for(int i = 0; i < Steps; i++)
	{
		CURAND_CALL(curandGenerateUniform(gen, d_r, N));

		spin_simulate <<<n_blocks, cuBlockSize>>> (m_d, d_r, N, nAtoms, J, T);	// kernel invocation
	}	

	CUDA_CALL(cudaThreadSynchronize());			// by default kernel runs in parallel with CPU code
    
    CUDA_CALL(cudaMemcpy(m, m_d, size, cudaMemcpyDeviceToHost));   	
	
	CURAND_CALL(curandDestroyGenerator(gen));

    CUDA_CALL(cudaFree(m_d));

	CUDA_CALL(cudaFree(d_r));

	return 0;
}