import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
	router: Router;

	configureRouter(config: RouterConfiguration, router: Router) {
		config.title = 'Motherlode';
		config.map([{
			route: ['', 'rigs'],
			name: 'rigs',
			settings: { icon: 'th-list' },
			moduleId: PLATFORM.moduleName('mining/rigs/views/rigs'),
			nav: true,
			title: 'Rigs'
		}]);

		this.router = router;
	}
}
