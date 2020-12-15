import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AccordionModule } from "primeng/accordion";
import { ButtonModule } from "primeng/button";
import { TableModule } from "primeng/table";
import { InputTextModule } from "primeng/inputtext";
import { InputNumberModule } from "primeng/inputnumber";
import { DropdownModule } from "primeng/dropdown";
import { ToastModule } from "primeng/toast";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { ApplicationComponent } from "./application/application.component";
import { MessageService } from "primeng/api";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ApplicationComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AccordionModule,
    ButtonModule,
    DropdownModule,
    InputNumberModule,
    InputTextModule,
    TableModule,
    ToastModule,
    RouterModule.forRoot(
      [{ path: "", component: ApplicationComponent, pathMatch: "full" }],
      { relativeLinkResolution: "legacy" }
    ),
  ],
  providers: [MessageService],
  bootstrap: [AppComponent],
})
export class AppModule {}
