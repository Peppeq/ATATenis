import Vue from "vue";
import Vuex from "vuex";
import { AlertModule } from "./modules/alert";
// import { users } from "./modules/users";
import { accountModule } from "./modules/account";

Vue.use(Vuex);

const alertModule = new AlertModule();

export const store = new Vuex.Store({
	modules: {
		alertModule,
		accountModule
	}
});
