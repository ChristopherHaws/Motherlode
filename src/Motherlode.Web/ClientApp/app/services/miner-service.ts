import { HttpClient, json } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';

@autoinject
export class MinerService {
	private http: HttpClient;

	constructor(http: HttpClient) {
		this.http = http;
	}

	public getAll(): Promise<Miner[]> {
		return this.http.fetch('/api/miners')
			.then(result => result.json() as Promise<Miner[]>);
	}

	public async getAll2(): Promise<Miner[]> {
		let result = await this.http.fetch('/api/miners');

		return result.json() as Promise<Miner[]>;
	}
}

export interface Miner {
	name: string;
}
