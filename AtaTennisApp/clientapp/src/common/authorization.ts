import { UserDTO } from "@/Api/UserController";

export interface AuthorizationHeader {
	Authorization: string;
}

export class Authorization {
	public static getAuthHeader(): AuthorizationHeader {
		// return authorization header with jwt token
		const user: UserDTO = JSON.parse(sessionStorage.getItem("user"));
		if (user && user.Token) {
			return { Authorization: "Bearer " + user.Token };
		} else {
			return null;
		}
	}

	public static getUser(): UserDTO {
		return JSON.parse(sessionStorage.getItem("user"));
	}

	public static isAdmin(): boolean {
		return this.getUser() != null && this.getUser().Username == "admin";
	}

	public static setUser(user: UserDTO): void {
		sessionStorage.setItem("user", JSON.stringify(user));
	}

	public static removeUser(): void {
		sessionStorage.removeItem("user");
	}
}
