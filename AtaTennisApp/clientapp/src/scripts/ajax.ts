import { NotificationUtils } from "../common/notification";

const enum ApiMethod {
    GET = "GET",
    POST = "POST",
    DELETE = "DELETE"
}

export class AjaxProvider {

    private static getApiUrl(methodName: string): string {
        // var url = window.location.href;
        var url: string = "http://localhost:55000";
        var apiUrl: string = url + "/api/" + methodName;
        console.log(apiUrl);
        return apiUrl;
    }

    private static apiCall<TResult, TArgs>(apiPath: string, data: TArgs, apiMethod: ApiMethod): Promise<TResult> {
        var apiUrl: string = this.getApiUrl(apiPath);
        var urlObj: URL = new URL(apiUrl);
        if (data != null) {
            var param: URLSearchParams = new URLSearchParams;
            Object.keys(data).forEach(key => {
                // @ts-ignore
                var argKey: string = data[key];
                param.append(key, argKey);
            });
            urlObj.search = param.toString();
        }

        let requestInit: RequestInit = null;
        if (apiMethod === ApiMethod.GET) {
            requestInit = {
                method: apiMethod.toString()
            };
        } else if (apiMethod === ApiMethod.POST) {
            requestInit = {
                method: apiMethod.toString(),
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data)
            };
        } else if (apiMethod === ApiMethod.DELETE) {
            requestInit = {
                method: apiMethod.toString()
            };
        }

        return fetch(urlObj.toString(), requestInit).then(function (response: Response): Promise<TResult> {
            if (!response.ok) {
                throw new Error(response.status.toString());
            }
            return response.json() as Promise<TResult>;
        });

    }

    public static apiGet<TResult, TArgs>(apiPath: string, data: TArgs): Promise<TResult> {
        return this.apiCall(apiPath, data, ApiMethod.GET);
    }

    public static apiPost<TResult, TArgs>(apiPath: string, data: TArgs): Promise<TResult> {
        return this.apiCall(apiPath, data, ApiMethod.POST);
    }

    public static apiDelete<TResult, TArgs>(apiPath: string, data: TArgs): Promise<TResult> {
        return this.apiCall(apiPath, data, ApiMethod.DELETE);
        console.log('abc');
    }

    // public static apiPost<TArgs, TResult>(apiPath: string, data: TArgs): Promise<TResult> {
    //     var url: string = window.location.href;
    //     var apiUrl: string = url + apiPath;
    //     var urlObj: URL = new URL(apiUrl);
    //     var param: URLSearchParams = new URLSearchParams;
    //     Object.keys(data).forEach(key => {
    //         // @ts-ignore
    //         param.append(key, data[key]);
    //     });
    //     urlObj.search = param.toString();
    //     var urlWithParams: string = urlObj.toString();

    //     return fetch(urlWithParams, {
    //         method: "POST",
    //         headers: {
    //             "Content-Type": "application/json",
    //         },
    //         body: JSON.stringify(data)
    //     }).then(function (response: Response): Promise<TResult> {
    //         if (!response.ok) {
    //             throw new Error(response.statusText);
    //         }
    //         return response.json() as Promise<TResult>;
    //     });
    // }
}