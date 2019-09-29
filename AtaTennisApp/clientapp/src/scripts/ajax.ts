﻿import { getAuthHeader, AuthorizationHeader } from "@/common/authorization-header";

const enum ApiMethod {
	GET = "GET",
	POST = "POST",
	DELETE = "DELETE"
}

export interface ErrorResponse {
	StatusCode: string;
	StatusDescription: string;
	Message: string;
}

export class AjaxProvider {
	private static getApiUrl(methodName: string): string {
		// var url = window.location.href;
		var url = "http://localhost:55000";
		var apiUrl: string = url + "/api/" + methodName;
		return apiUrl;
	}

	private static apiCall<TResult, TArgs>(apiPath: string, data: TArgs, apiMethod: ApiMethod): Promise<TResult> {
		var apiUrl: string = this.getApiUrl(apiPath);
		console.log("api path called: " + apiUrl);

		var urlObj: URL = new URL(apiUrl);
		if (data != null) {
			var param: URLSearchParams = new URLSearchParams();
			Object.keys(data).forEach((key: string): void => {
				// @ts-ignore
				var argKey: string = data[key];
				if (argKey != null) {
					param.append(key, argKey);
				}
			});
			urlObj.search = param.toString();
		}

		let authorization: AuthorizationHeader = getAuthHeader();
		let requestInit: RequestInit = null;
		let bodyJson: string = null;

		if (apiMethod === ApiMethod.POST) {
			bodyJson = JSON.stringify(data);
		}

		requestInit = {
			method: apiMethod.toString(),
			headers: {
				...authorization,
				"Content-Type": "application/json"
			},
			body: bodyJson
		};
		console.log(authorization);
		return fetch(urlObj.toString(), requestInit)
			.then(function(response: Response): Promise<TResult> {
				if (!response.ok) {
					// throw new Error(response.status.toString());
					// throwing response in order to move all response with body error message from my API (catched by BaseComponentClass)
					throw response;
				}
				return response.json() as Promise<TResult>;
			})
			.catch(
				(e): Promise<TResult> => {
					console.log("catch in AjaxProvider");
					console.log(e);
					throw e;
				}
			);
	}

	public static apiGet<TResult, TArgs>(apiPath: string, data: TArgs): Promise<TResult> {
		return this.apiCall(apiPath, data, ApiMethod.GET);
	}

	public static apiPost<TResult, TArgs>(apiPath: string, data: TArgs): Promise<TResult> {
		return this.apiCall(apiPath, data, ApiMethod.POST);
	}

	public static apiDelete<TResult, TArgs>(apiPath: string, data: TArgs): Promise<TResult> {
		return this.apiCall(apiPath, data, ApiMethod.DELETE);
	}
}