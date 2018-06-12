import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'error',
    templateUrl: './error.component.html'
})

export class ErrorComponent implements OnInit {
    errorMsg: string="";
    stackTrace: string="";
    constructor(private route: ActivatedRoute) { }

    ngOnInit() {
        this.errorMsg = this.route.snapshot.params['errMsg'];
        this.stackTrace = this.route.snapshot.params['stackTrace'];
    }
}