import { Player } from "./PlayerController";

export class Players {
    async getData(): Promise<Player> {
        return fetch("/api/Player", {
            method: "get"
        }).then(function (response: Response): Promise<Player> {
            return response.json();
        });
    }

    sayHello(): void {
        alert("hello");
    }
}
