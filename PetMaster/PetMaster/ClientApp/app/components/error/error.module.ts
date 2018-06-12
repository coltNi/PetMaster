import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { routing } from '../../app.routing';
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { ErrorComponent } from './error.component';
import { GlobalErrorHandler } from '../shared/global-error-handler'


@NgModule({
    declarations: [
        ErrorComponent
    ],
    imports: [routing, HttpModule, JsonpModule, CommonModule, FormsModule],
    providers: [GlobalErrorHandler],
    exports: []
})
export class ErrorModule { }