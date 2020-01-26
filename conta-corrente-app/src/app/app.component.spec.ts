import { TestBed, async } from "@angular/core/testing";
import { AppComponent } from "./app.component";
import { ContaCorrenteComponent } from "./conta-corrente/conta-corrente.component";
import { ReactiveFormsModule } from "@angular/forms";
import { NgxCurrencyModule } from "ngx-currency";
import { HttpClientModule } from "@angular/common/http";
import { ToastrModule } from "ngx-toastr";

describe("AppComponent", () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        ReactiveFormsModule,
        NgxCurrencyModule,
        ToastrModule.forRoot()
      ],
      declarations: [AppComponent, ContaCorrenteComponent]
    }).compileComponents();
  }));

  it("should create the app", () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });
});
