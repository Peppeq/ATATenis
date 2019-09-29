// tslint:disable-next-line:no-console
// eslint-disable-next-line
console.log("nazdar from testsJs.js file");

const enum AccountStateStatus {
	loggedIn,
	loggingIn,
	registering,
	none
}

class TestClass {
	private status: AccountStateStatus = null;
	public testFunc(): void {
		this.status = AccountStateStatus.none;
	}
}
