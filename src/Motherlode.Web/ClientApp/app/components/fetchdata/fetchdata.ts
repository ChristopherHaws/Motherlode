import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Fetchdata {
	public gpus: Gpu[];

	constructor(http: HttpClient) {
		http.fetch('/api/gpu')
			.then(result => result.json() as Promise<Gpu[]>)
			.then(data => {
				this.gpus = data;
			});
	}
}

interface Gpu {
	id: number;
	temperatureC: number;
	temperatureF: number;
	name: string;
}
