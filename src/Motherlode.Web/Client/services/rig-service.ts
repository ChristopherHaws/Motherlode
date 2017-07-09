import { HttpClient, json } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';

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

export interface Rig {
	id: string;
	name: string;
	ipAddress: string;
	firstSeen?: Date;
	lastSeen?: Date;
}
