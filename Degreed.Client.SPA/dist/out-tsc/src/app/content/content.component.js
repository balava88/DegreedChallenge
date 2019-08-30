import * as tslib_1 from "tslib";
import { interval } from 'rxjs';
import { Component } from '@angular/core';
import { ApiService } from '../Services/api.service';
import { FormBuilder, Validators } from '@angular/forms';
var ContentComponent = /** @class */ (function () {
    function ContentComponent(apiService, formBuilder) {
        this.apiService = apiService;
        this.formBuilder = formBuilder;
        this.hasSearched = false;
        this.hasResults = false;
    }
    ContentComponent.prototype.ngOnInit = function () {
        var _this = this;
        // Create form
        this.createForm();
        // Set interval for joke fetching
        var source = interval(10000);
        this.getNewJoke();
        this.subscription = source.subscribe(function (val) { return _this.apiService.getJoke().subscribe(function (data) {
            console.log(data);
            _this.joke = data;
        }, function (error) {
            console.log(error);
        }); });
    };
    // Get new joke from button
    ContentComponent.prototype.getNewJoke = function () {
        var _this = this;
        this.apiService.getJoke().subscribe(function (data) {
            _this.joke = data;
        }, function (error) {
            console.log(error);
        });
    };
    ContentComponent.prototype.createForm = function () {
        this.formGroup = this.formBuilder.group({
            searchedValue: [null, [Validators.required, Validators.maxLength(30)]]
        });
    };
    // Search jokes by a term
    ContentComponent.prototype.searchTerm = function (searchedTerm) {
        var _this = this;
        this.searchedTerm = searchedTerm.searchedValue;
        this.apiService.seachJokesByTerm(searchedTerm).subscribe(function (data) {
            console.log(data);
            _this.smallJokes = data.results.filter(function (item) { return item.JokeLength === 10; });
            _this.mediumJokes = data.results.filter(function (item) { return item.JokeLength === 20; });
            _this.longJokes = data.results.filter(function (item) { return item.JokeLength === 30; });
            _this.hasSearched = true;
            _this.hasResults = true;
        }, function (error) {
            _this.hasResults = false;
            _this.hasSearched = true;
        });
    };
    ContentComponent = tslib_1.__decorate([
        Component({
            selector: 'app-content',
            templateUrl: './content.component.html',
            styleUrls: ['./content.component.css'],
            providers: [ApiService]
        }),
        tslib_1.__metadata("design:paramtypes", [ApiService, FormBuilder])
    ], ContentComponent);
    return ContentComponent;
}());
export { ContentComponent };
//# sourceMappingURL=content.component.js.map