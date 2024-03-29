/* eslint-disable @typescript-eslint/no-use-before-define */
import { UserDTO } from "@/Api/dtos/UserDTO";
import { UserClient } from "@/Api/UserController";
import { Authorization } from "@/common/authorization";

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
  return await userClient
    .authenticate({ password, username, token: null })
    .then(
      (user: UserDTO): UserDTO => {
        // login successful if there's a jwt token in the response
        if (user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          Authorization.setUser(user);
          console.log("successful authentication");
        }

        return user;
      }
    )
    .catch(
      (e): Promise<UserDTO> => {
        console.log(e);
        throw e;
      }
    );
}

export function logout(): void {
  // remove user from local storage to log user out
  Authorization.removeUser();
}

async function register(user: UserDTO): Promise<void> {
  await userClient.register(user);
}

async function getAll(): Promise<UserDTO[]> {
  return await userClient.getAll();
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
