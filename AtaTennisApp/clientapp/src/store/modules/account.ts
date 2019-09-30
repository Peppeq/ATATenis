// @ts-nocheck
import { userService } from "../../views/user/helper/user-service";
import { UserDTO } from "@/Api/UserController";
import { router } from '@/router';
import { ErrorResponse } from '@/scripts/ajax';
import { NotificationUtils } from '@/common/notification';

export interface AccountStateStatus {
	loggedIn: boolean;
	loggingIn: boolean;
	registering: boolean;
}

interface AccountState {
	status: AccountStateStatus;
	user: UserDTO;
}

const user = JSON.parse(localStorage.getItem("user"));
const state: AccountState = user
	? { status: { loggedIn: true,loggingIn:false,registering:false }, user }
	: { status: null, user: null };

const actions = {
	login({ dispatch, commit }: any, userDto: UserDTO) {
		commit("loginRequest", userDto.Username);
		userService.login(userDto.Username, userDto.Password).then(
			user => {
				commit("loginSuccess", user);
				router.push("/dashboard");
			}
		).catch(error => {
			console.log(error.json().then((e: ErrorResponse) => {
				console.log(e)
				commit("loginFailure");
				dispatch("alertModule/error", e.Message, { root: true });
				NotificationUtils.ShowErrorMessage(e.Message);
			}));
		});
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
		state.status = { loggedIn: true,loggingIn:false,registering:false };
		state.user = accountState.user;
	},
	loginFailure() {
		state.status = null;
		state.user = null;
	},
	logout() {
		state.status = null;
		state.user = null;
	},
	registerRequest() {
		state.status = { loggedIn: false,loggingIn:false,registering:true };
	},
	registerSuccess() {
		state.status = null;
	},
	registerFailure() {
		state.status = null;
	}
};

export const accountModule = {
	namespaced: true,
	state,
	actions,
	mutations
};
