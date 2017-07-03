﻿import { HttpClient, json } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';

@autoinject
export class MinerService {
	private http: HttpClient;

	constructor(http: HttpClient) {
		this.http = http;
	}
	
	public async getAll(): Promise<Miner[]> {
		let result = await this.http.fetch('/api/miners');

		return result.json() as Promise<Miner[]>;
	}
}

export interface Miner {
	name: string;
}
