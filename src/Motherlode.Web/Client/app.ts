import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
	router: Router;

	configureRouter(config: RouterConfiguration, router: Router) {
		config.title = 'Motherlode';
		config.map([{
			route: ['', 'home'],
			name: 'home',
			settings: { icon: 'home' },
			moduleId: PLATFORM.moduleName('pages/home/home'),
			nav: true,
			title: 'Home'
		}, {
			route: 'rigs',
			name: 'rigs',
			settings: { icon: 'th-list' },
			moduleId: PLATFORM.moduleName('pages/rigs/rigs'),
			nav: true,
			title: 'Rigs'
		}, {
			route: 'agents',
			name: 'agents',
			settings: { icon: 'education' },
			moduleId: PLATFORM.moduleName('pages/agents/agents'),
			nav: true,
			title: 'Agents'
		}]);

		this.router = router;
	}
}
