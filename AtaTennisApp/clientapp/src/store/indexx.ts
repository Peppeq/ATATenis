import Vue from "vue";
import Vuex from "vuex";
import { createDirectStore } from "direct-vuex";
import { AlertModule } from "./modules/alert";
// import { users } from "./modules/users";
import { accountModule } from "./modules/account";

Vue.use(Vuex);

const alertModule = new AlertModule();

// original classic vuex
// export const store = new Vuex.Store({
// 	modules: {
// 		alertModule,
// 		accountModule
// 	}
// });

const { store, rootActionContext, moduleActionContext } = createDirectStore({
  modules: {
    alertModule,
    accountModule
  }
});

// Export the direct-store instead of the classic Vuex store.
export default store;

// The following exports will be used to enable types in the
// implementation of actions.
export { rootActionContext, moduleActionContext };

// The following lines enable types in the injected store '$store'.
export type AppStore = typeof store;
declare module "vuex" {
  interface Store<S> {
    direct: AppStore;
  }
}
