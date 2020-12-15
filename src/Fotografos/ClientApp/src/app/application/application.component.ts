import { Component, OnInit } from "@angular/core";
import { Application } from "../model/Application";
import { Photographer } from "../model/Photographer";
import { ApplicationService } from "./services/application.service";

@Component({
  selector: "app-application",
  templateUrl: "./application.component.html",
  styleUrls: ["./application.component.css"],
})
export class ApplicationComponent implements OnInit {
  constructor(private applicationService: ApplicationService) {}

  applications?: Application[];

  photographers?: Photographer[];

  cols: any[];

  ngOnInit(): void {
    this.getApplications();

    this.cols = [
      { field: "id", header: "Id" },
      { field: "photographerId", header: "Photographer", type: "Photographer" },
      { field: "date", header: "Date" },
      { field: "equipmentDescription", header: "Equipment Description" },
      { field: "resume", header: "Resume" },
    ];
  }
  getApplications(): void {
    this.applicationService
      .getApplications()
      .subscribe((as) => (this.applications = as));
  }
}
