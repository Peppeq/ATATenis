const enum AlertType{
	error = "alert-danger",
	succes = "alert-success"
}

interface AlertModuleState{
	type: AlertType,
	message: string
}

const alertActions = {
	success({ commit}: any, message: string) {
		commit("success", message);
	},
	error({ commit }: any, message: any) {
		commit("error", message);
	},
	clear({ commit }: any, message: any) {
		commit("success", message);
	}
};

const alertMutations = {
	success(state: AlertModuleState, message: any) {
		state.type = AlertType.succes;
		state.message = message;
	},
	error(state: AlertModuleState, message: any) {
		state.type = AlertType.error;
		state.message = message;
	},
	clear(state: AlertModuleState) {
		state.type = null;
		state.message = null;
	}
};

export class AlertModule {
	namespaced: boolean = true;
	state: AlertModuleState = {message:null, type: null};
	actions = alertActions;
	mutations = alertMutations;
}
