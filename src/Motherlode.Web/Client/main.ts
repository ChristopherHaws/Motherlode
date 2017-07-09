import 'isomorphic-fetch';
import { Aurelia, PLATFORM } from 'aurelia-framework';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap';
declare const IS_DEV_BUILD: boolean; // The value is supplied by Webpack during the build

export function configure(aurelia: Aurelia) {
	aurelia.use
		.standardConfiguration();
		//.globalResources([
		//	"./resources/value-converters/not-null"
		//]);

	if (IS_DEV_BUILD) {
		aurelia.use.developmentLogging();
	}

	aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}
