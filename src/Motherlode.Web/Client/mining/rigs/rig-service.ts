import { HttpClient, json } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';
import { Rig } from './models';

@autoinject
export class RigService {
	private http: HttpClient;

	constructor(http: HttpClient) {
		this.http = http;
	}
	
	public async getAll(): Promise<Rig[]> {
		let result = await this.http.fetch('/api/rigs');

		return await result.json() as Promise<Rig[]>;
	}
}
