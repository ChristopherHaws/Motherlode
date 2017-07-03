import { HttpClient, json } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';

import { MinerService, Miner } from '../../services/miner-service';
import { GpuService, Gpu } from '../../services/gpu-service';

@autoinject
export class Fetchdata {
	private http: HttpClient;
	private minerService: MinerService;
	private gpuService: GpuService;

	public gpus: Gpu[];
	public miners: Miner[];

	constructor(http: HttpClient, minerService: MinerService, gpuService: GpuService) {
		this.http = http;
		this.minerService = minerService;
		this.gpuService = gpuService;
	}

	public async activate(params): Promise<void> {
		this.miners = await this.minerService.getAll();
		this.gpus = await this.gpuService.getAll();
	}
	
	public async enable(gpu: Gpu): Promise<void> {
		await this.gpuService.enable(gpu);
	}

	public async disable(gpu: Gpu): Promise<void> {
		await this.gpuService.disable(gpu);
	}

	public async changeMiner(gpu: Gpu): Promise<void> {
		console.log(gpu.minerName);

		await this.gpuService.save(gpu);
	}
}
