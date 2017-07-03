import { HttpClient, json } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';

@autoinject
export class GpuService {
	private http: HttpClient;

	constructor(http: HttpClient) {
		this.http = http;
	}
	
	public async getAll(): Promise<Gpu[]> {
		let result = await this.http.fetch('/api/gpus');

		return await result.json() as Promise<Gpu[]>;
	}

	public async save(gpu: Gpu): Promise<void> {
		await this.http.fetch(`/api/gpus/${gpu.id}`, {
			method: 'put',
			body: json(gpu)
		});
	}

	public async enable(gpu: Gpu): Promise<void> {
		gpu.isEnabled = true;

		await this.http.fetch(`/api/gpus/${gpu.id}/enable`, {
			method: 'put'
		});
	}

	public async disable(gpu: Gpu): Promise<void> {
		gpu.isEnabled = false;

		await this.http.fetch(`/api/gpus/${gpu.id}/disable`, {
			method: 'put'
		});
	}
}

export interface Gpu {
	id: number;
	temperatureC: number;
	name: string;
	minerName: string;
	isEnabled: boolean;
}
