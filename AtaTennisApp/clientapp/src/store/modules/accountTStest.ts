// /* eslint-disable @typescript-eslint/no-use-before-define */
// /* eslint-disable @typescript-eslint/explicit-function-return-type */
// /* eslint-disable @typescript-eslint/explicit-member-accessibility */
// import { userService } from "../../views/user/helper/user-service";
// import { UserDTO } from "@/Api/UserController";
// import { vuexTsModuleBuilder, VuexTsModule, ModuleActions, usedIn, ModuleMutations } from "vuex-ts";

// interface UserStatus {
// 	loggedIn: boolean;
// }

// interface AccountModuleState {
// 	status: UserStatus;
// 	user: UserDTO;
// }

// const initialUserModuleState: AccountModuleState = {
// 	status: { loggedIn: false },
// 	user: null
// };

// const user: UserDTO = JSON.parse(localStorage.getItem("user"));
// const state: AccountModuleState = user ? { status: { loggedIn: true }, user } : { status: null, user: null };

// export class AccountModuleActions extends ModuleActions {
// 	[usedIn] = () => AccountModule;

// 	async login({ commit }, { password: string, username: string }) {
// 		this[mutations].commit("loginRequest", { username });
// 		userService.login(username, password).then(
// 			user => {
// 				commit("loginSuccess", user);
// 				router.push("/");
// 			},
// 			error => {
// 				commit("loginFailure", error);
// 				dispatch("alert/error", error, { root: true });
// 			}
// 		);
// 	}
// 	// logout({ commit }) {
// 	// 	userService.logout();
// 	// 	commit("logout");
// 	// },
// 	// register({ dispatch, commit }, user) {
// 	// 	commit("registerRequest", user);
// 	// 	userService.register(user).then(
// 	// 		user => {
// 	// 			commit("registerSuccess", user);
// 	// 			router.push("/login");
// 	// 			setTimeout(() => {
// 	// 				// display success message after route change completes
// 	// 				dispatch("alert/success", "Registration successful", { root: true });
// 	// 			});
// 	// 		},
// 	// 		error => {
// 	// 			commit("registerFailure", error);
// 	// 			dispatch("alert/error", error, { root: true });
// 	// 		}
// 	// 	);
// 	// }
// }

// export class AccountModuleMutations extends ModuleMutations {
// 	[usedIn] = () => AccountModule;

// 	// loginRequest(state, user) {
// 	// 	state.status = { loggingIn: true };
// 	// 	state.user = user;
// 	// },
// 	// loginSuccess(state, user) {
// 	// 	state.status = { loggedIn: true };
// 	// 	state.user = user;
// 	// },
// 	// loginFailure(state) {
// 	// 	state.status = {};
// 	// 	state.user = null;
// 	// },
// 	// logout(state) {
// 	// 	state.status = {};
// 	// 	state.user = null;
// 	// },
// 	// registerRequest(state, user) {
// 	// 	state.status = { registering: true };
// 	// },
// 	// registerSuccess(state, user) {
// 	// 	state.status = {};
// 	// },
// 	// registerFailure(state, error) {
// 	// 	state.status = {};
// 	// }
// }

// export class AccountModule extends VuexTsModule<AccountModuleState> {
// 	name = "accountModule";
// 	namespaced: boolean = true;

// 	state = () => initialUserModuleState;
// 	actions = () => AccountModuleActions;
// 	mutations = () => AccountModuleMutations;
// }

// export const accountModuleInstace = vuexTsModuleBuilder(AccountModule);
