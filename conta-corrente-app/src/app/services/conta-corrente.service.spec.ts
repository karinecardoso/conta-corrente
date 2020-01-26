import { TestBed } from "@angular/core/testing";

import { ContaCorrenteService } from "./conta-corrente.service";
import { HttpClientModule } from "@angular/common/http";

describe("ContaCorrenteService", () => {
  beforeEach(() =>
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    })
  );

  it("should be created", () => {
    const service: ContaCorrenteService = TestBed.get(ContaCorrenteService);
    expect(service).toBeTruthy();
  });
});
