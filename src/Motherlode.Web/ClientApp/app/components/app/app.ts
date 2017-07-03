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
			route: 'counter',
			name: 'counter',
			settings: { icon: 'education' },
			moduleId: PLATFORM.moduleName('../counter/counter'),
			nav: true,
			title: 'Counter'
		}]);

		this.router = router;
	}
}
