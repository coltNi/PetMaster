import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
    errorMsg: string = "";
    stackTrace: string = "";
    constructor(private injector: Injector) {
    }
    handleError(error: any) {
        var router = this.injector.get(Router);

        if (error._body != null && error._body !== "undefined") {
            this.errorMsg = JSON.parse(error._body).message;
            this.stackTrace = JSON.parse(error._body).stackTrace;
        } else {
            this.errorMsg = error.message;
            this.stackTrace = error.stack;
        }
        router.navigate(['/error', { errMsg: this.errorMsg, stackTrace: this.stackTrace }]);
    }
}