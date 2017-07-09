export class NotNullValueConverter {
	toView(array: {}[]) {
		if (!array) {
			return array;
		}

		return array.filter(item => item !== null);
	}
}
