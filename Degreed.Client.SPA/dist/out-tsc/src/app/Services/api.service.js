import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var ApiService = /** @class */ (function () {
    function ApiService(http) {
        this.http = http;
        this.baseUrl = 'http://localhost:9445/api/Jokes/';
    }
    // Get a new random joke form API
    ApiService.prototype.getJoke = function () {
        return this.http.get(this.baseUrl + "RandomJoke", { headers: { Accept: 'application/json' } });
    };
    // Get jokes containing term
    ApiService.prototype.seachJokesByTerm = function (searchedTerm) {
        var requestURL = this.baseUrl + "JokesByTerm/?term=" + searchedTerm.searchedValue;
        return this.http.get(requestURL, { headers: { Accept: 'application/json' } });
    };
    ApiService = tslib_1.__decorate([
        Injectable({
            providedIn: 'root'
        }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], ApiService);
    return ApiService;
}());
export { ApiService };
//# sourceMappingURL=api.service.js.map