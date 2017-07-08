import { autoinject } from 'aurelia-framework';

import { MinerService, Miner } from '../../services/miner-service';
import { GpuService, Gpu } from '../../services/gpu-service';

@autoinject
export class RigView {
	private minerService: MinerService;
	private gpuService: GpuService;
	private isRunning: boolean;

	public gpus: Gpu[];
	public miners: Miner[];

	constructor(minerService: MinerService, gpuService: GpuService) {
		this.minerService = minerService;
		this.gpuService = gpuService;
	}

	public async activate(params): Promise<void> {
		this.miners = await this.minerService.getAll();
		this.gpus = await this.gpuService.getAll();
		this.run();
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

	public detached() {
		this.isRunning = false;
	}

	private run(): void {
		this.isRunning = true;

		setTimeout(async () => {
			if (!this.isRunning) {
				return;
			}

			this.gpus = await this.gpuService.getAll();
			this.run();
		}, 3000);
	}
}
