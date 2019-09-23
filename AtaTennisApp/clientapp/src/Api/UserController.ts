﻿
/* eslint-disable */
// this file is autogenerated by typewriter (used Template.tst file to generate)

import { AjaxProvider } from "../scripts/ajax";



export class UserDTO {
    Username: string = null;
    Password: string = null;
    Email: string = null;
}



export default class UserClient {

    authenticate<TArgs extends UserDTO, TResult extends any>(data: TArgs): Promise<TResult> {
        return AjaxProvider.apiPost("User", data);
    }

    register<TArgs extends UserDTO, TResult extends any>(data: TArgs): Promise<TResult> {
        return AjaxProvider.apiPost("User", data);
    }

    getWithoutParams<TResult extends any>(): Promise<TResult> {
        return AjaxProvider.apiGet("User", null);
    }

    getById<TArgs extends number, TResult extends any>(data: TArgs): Promise<TResult> {
        return AjaxProvider.apiGet("User", data);
    }

    delete<TArgs extends number, TResult extends any>(data: TArgs): Promise<TResult> {
        return AjaxProvider.apiDelete("User", data);
    }
}
