import * as tslib_1 from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DemoMaterialModule } from 'src/angular-material.module';
import { ContentComponent } from './content/content.component';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { OverlayModule } from '@angular/cdk/overlay';
import { MatTableModule } from '@angular/material';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib_1.__decorate([
        NgModule({
            declarations: [
                AppComponent,
                ContentComponent,
            ],
            imports: [
                BrowserModule,
                AppRoutingModule,
                BrowserAnimationsModule,
                DemoMaterialModule,
                HttpClientModule,
                FlexLayoutModule,
                FormsModule,
                OverlayModule,
                MatTableModule,
                ReactiveFormsModule,
                RouterModule.forRoot(appRoutes)
            ],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map