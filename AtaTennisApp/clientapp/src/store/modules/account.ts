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
		dispatch("testDispatch", "dispatchujem pre consolu test akciu");
		commit("loginRequest", userDto.Username);
		userService.login(userDto.Username, userDto.Password).then(
			user => {
				commit("loginSuccess", user);
				router.push("/dashboard/playerManagement");
			}
		).catch((error: ErrorResponse) => {
			console.log(error)
			commit("loginFailure");
			dispatch("alertModule/error", error.Message, { root: true });
			NotificationUtils.ShowErrorMessage(error.Message);
		});
	},
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
	testDispatch({ dispatch, commit }, message: string) {
		console.log(message);
	}
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
	namespaced: true as true,
	state,
	actions,
	mutations
};
