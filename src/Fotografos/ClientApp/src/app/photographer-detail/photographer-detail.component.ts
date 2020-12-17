import { Component, OnInit } from "@angular/core";
import { PhotographerService } from "../application/services/photographer.service";
import { Photographer } from "../model/Photographer";

@Component({
  selector: "app-photographer-detail",
  templateUrl: "./photographer-detail.component.html",
  styleUrls: ["./photographer-detail.component.css"],
})
export class PhotographerDetailComponent implements OnInit {
  constructor(private photographerService: PhotographerService) {}

  photographer?: Photographer;

  ngOnInit(): void {
    this.photographer = {} as Photographer;
  }

  createPhotographer(): void {
    if (
      !this.photographer.name.trim() ||
      !this.photographer.surename.trim() ||
      !this.photographer.address.trim() ||
      !this.photographer.city.trim() ||
      this.photographer.postalCode == 0 ||
      this.photographer.telephone == 0
    ) {
      return null;
    }

    this.photographerService
      .createPhotographer(this.photographer)
      .subscribe((p) => {
        if (!p) {
          return;
        }

        this.photographer = {} as Photographer;
      });
  }
}
