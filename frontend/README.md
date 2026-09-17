# 🎨 RentAWhip - Frontend Angular SPA

Designed and created by **Ege Duyar**.

This directory contains the **Angular 11** Single Page Application for **RentAWhip**.

For complete full-stack instructions, system design breakdown, and explanation of how RentAWhip works under the hood, refer to the [Master Project README](../README.md).

---

## 📱 Features & Components

- **Navigation & Brand Bar (`NaviComponent`)**: Category shortcuts, dynamic user profile header, and color/brand filter dropdowns.
- **Car Catalog & Details (`CarComponent`, `CarDetailComponent`)**: Interactive grid listing vehicle specs, images, daily rental rates, and filter pipes.
- **Rental & Payment Flow (`RentAddComponent`, `PaymentComponent`)**: Date selection, Findeks credit score verification, double-booking prevention, mock bank card settlement, and credit card saving options.
- **Authentication & User Profile (`LoginComponent`, `RegisterComponent`)**: JWT storage integration with `LocalStorageService` and dynamic auth state.

---

## 🚀 Development Server

Run `ng serve` for a development server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

```bash
# Install dependencies
npm install

# Start local server
ng serve
```

---

## 📦 Production Build

Run `ng build --prod` to build the project. The build artifacts will be stored in the `dist/` directory.
