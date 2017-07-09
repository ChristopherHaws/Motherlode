import { Rig } from '../models';
import { Gpu } from '../../gpus';

export class RigFilterValueConverter {
	toView(gpus: Gpu[], rig: Rig) {
		if (!gpus || !rig) {
			return gpus;
		}

		return gpus.filter(gpu => gpu.rigName === rig.name);
	}
}
