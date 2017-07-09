import { Gpu, Rig } from '../../../services';

export class RigFilterValueConverter {
	toView(gpus: Gpu[], rig: Rig) {
		if (!gpus || !rig) {
			return gpus;
		}

		return gpus.filter(gpu => gpu.rigName === rig.name);
	}
}
