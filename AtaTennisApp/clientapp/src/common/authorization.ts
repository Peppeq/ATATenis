import { UserDTO } from "@/Api/dtos/UserDTO";

export interface AuthorizationHeader {
	Authorization: string;
}

export class Authorization {
  public static getAuthHeader(): AuthorizationHeader {
    // return authorization header with jwt token
    const user: UserDTO = JSON.parse(sessionStorage.getItem("user"));
    if (user && user.token) {
      return { Authorization: "Bearer " + user.token };
    } else {
      return null;
    }
  }

  public static getUser(): UserDTO {
    return JSON.parse(sessionStorage.getItem("user"));
  }

  public static isAdmin(): boolean {
    return this.getUser() != null && this.getUser().username == "admin";
  }

  public static setUser(user: UserDTO): void {
    sessionStorage.setItem("user", JSON.stringify(user));
  }

  public static removeUser(): void {
    sessionStorage.removeItem("user");
  }
}
