/* eslint-disable @typescript-eslint/no-use-before-define */
import UserClient, { UserDTO } from "@/Api/UserController";

const userClient = new UserClient();

export const userService = {
	login,
	logout,
	register,
	getAll
	// getById,
	// update,
	// delete: _delete
};

async function login(username: string, password: string): Promise<UserDTO> {
	console.log("inside login func");
	return await userClient.authenticate({ Password: password, Username: username, Token: null }).then(
		(user: UserDTO): UserDTO => {
			// login successful if there's a jwt token in the response
			console.log("successful authentication");
			if (user.Token) {
				// store user details and jwt token in local storage to keep user logged in between page refreshes
				localStorage.setItem("user", JSON.stringify(user));
			}

			return user;
		}
	);
}

export function logout(): void {
	// remove user from local storage to log user out
	localStorage.removeItem("user");
}

async function register(user: UserDTO): Promise<void> {
	await userClient.register(user);
}

async function getAll(): Promise<UserDTO[]> {
	return await userClient.getWithoutParams();
}

// function getById(id) {
// 	const requestOptions = {
// 		method: "GET",
// 		headers: authHeader()
// 	};

// 	return fetch(`${config.apiUrl}/users/${id}`, requestOptions).then(handleResponse);
// }

// function update(user) {
// 	const requestOptions = {
// 		method: "PUT",
// 		headers: { ...authHeader(), "Content-Type": "application/json" },
// 		body: JSON.stringify(user)
// 	};

// 	return fetch(`${config.apiUrl}/users/${user.id}`, requestOptions).then(handleResponse);
// }

// // prefixed function name with underscore because delete is a reserved word in javascript
// function _delete(id) {
// 	const requestOptions = {
// 		method: "DELETE",
// 		headers: authHeader()
// 	};

// 	return fetch(`${config.apiUrl}/users/${id}`, requestOptions).then(handleResponse);
// }
