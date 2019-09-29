// @ts-nocheck
import { userService } from "../../views/user/helper/user-service";
import { UserDTO } from "@/Api/UserController";

export enum AccountStateStatus {
	loggedIn,
	loggingIn,
	registering,
	none
}

interface AccountState {
	status: AccountStateStatus;
	user: UserDTO;
}

const user = JSON.parse(localStorage.getItem("user"));
const state: AccountState = user
	? { status: AccountStateStatus.loggedIn, user }
	: { status: AccountStateStatus.none, user: null };

const actions = {
	login({ dispatch, commit }: any, userDto: UserDTO) {
		commit("loginRequest", userDto.Username);
		userService.login(userDto.Username, userDto.Password).then(
			user => {
				commit("loginSuccess", user);
				// router.push("/");
			},
			error => {
				commit("loginFailure", error);
				dispatch("alertModule/error", error, { root: true });
			}
		);
	}
	// logout({ commit }) {
	// 	userService.logout();
	// 	commit("logout");
	// },
	// register({ dispatch, commit }, user) {
	// 	commit("registerRequest", user);
	// 	userService.register(user).then(
	// 		user => {
	// 			commit("registerSuccess", user);
	// 			router.push("/login");
	// 			setTimeout(() => {
	// 				// display success message after route change completes
	// 				dispatch("alert/success", "Registration successful", { root: true });
	// 			});
	// 		},
	// 		error => {
	// 			commit("registerFailure", error);
	// 			dispatch("alert/error", error, { root: true });
	// 		}
	// 	);
	// }
};

const mutations = {
	loginRequest(accountState: AccountState) {
		state.status = accountState.status;
		state.user = accountState.user;
	},
	loginSuccess(accountState: AccountState) {
		state.status = AccountStateStatus.loggedIn;
		state.user = user;
	},
	loginFailure(accountState: AccountState) {
		state.status = AccountStateStatus.none;
		state.user = null;
	},
	logout() {
		state.status = AccountStateStatus.none;
		state.user = null;
	},
	registerRequest() {
		state.status = AccountStateStatus.registering;
	},
	registerSuccess() {
		state.status = AccountStateStatus.none;
	},
	registerFailure() {
		state.status = AccountStateStatus.none;
	}
};

export const accountModule = {
	namespaced: true,
	state,
	actions,
	mutations
};
