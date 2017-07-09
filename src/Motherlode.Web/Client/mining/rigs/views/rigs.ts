import { autoinject } from 'aurelia-framework';
import { Miner, MinerService } from '../../miners';
import { Gpu, GpuService } from '../../gpus';
import { Rig, RigService } from '../';

@autoinject
export class RigView {
	private minerService: MinerService;
	private gpuService: GpuService;
	private rigService: RigService;
	private isRunning: boolean;

	public rigs: Rig[];
	public gpus: Gpu[];
	public miners: Miner[];

	constructor(minerService: MinerService, gpuService: GpuService, rigService: RigService) {
		this.minerService = minerService;
		this.gpuService = gpuService;
		this.rigService = rigService;
	}

	public async activate(params): Promise<void> {
		await Promise.all([
			(async () => this.rigs = await this.rigService.getAll())(),
			(async () => this.miners = await this.minerService.getAll())(),
			(async () => this.gpus = await this.gpuService.getAll())()
		]);

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
		if (this.isRunning) {
			return;
		}

		this.isRunning = true;
		
		let interval = setInterval(async () => {
			if (!this.isRunning) {
				clearInterval(interval);
				return;
			}

			this.gpus = await this.gpuService.getAll();
		}, 3000);
	}
}
