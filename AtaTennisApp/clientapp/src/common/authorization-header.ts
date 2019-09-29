import { UserDTO } from "@/Api/UserController";

export interface AuthorizationHeader {
	Authorization: string;
}

export function getAuthHeader(): AuthorizationHeader {
	// return authorization header with jwt token
	let user: UserDTO = JSON.parse(localStorage.getItem("user"));
	if (user && user.Token) {
		return { Authorization: "Bearer " + user.Token };
	} else {
		return null;
	}
}
