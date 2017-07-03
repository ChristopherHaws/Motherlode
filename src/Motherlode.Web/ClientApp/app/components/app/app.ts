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
			moduleId: PLATFORM.moduleName('../home/home'),
			nav: true,
			title: 'Home'
		}, {
			route: 'gpu-page',
			name: 'gpupage',
			settings: { icon: 'th-list' },
			moduleId: PLATFORM.moduleName('../gpu-page/gpu-page'),
			nav: true,
			title: 'GPU\'s'
		}, {
			route: 'agents',
			name: 'agents',
			settings: { icon: 'education' },
			moduleId: PLATFORM.moduleName('../agents/agents'),
			nav: true,
			title: 'Agents'
		}]);

		this.router = router;
	}
}
