import Footer from "@/components/templates/footer";
import MuiThemeProvider from "@/components/templates/mui";
import NavBar from "@/components/templates/navBar";
import { AppRouterCacheProvider } from "@mui/material-nextjs/v15-appRouter";
import type { Metadata } from "next";
import { Abril_Fatface, Geist, Geist_Mono } from "next/font/google";
import "./globals.css";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

const abril = Abril_Fatface({
  weight: "400",
  subsets: ["latin", "latin-ext"],
  variable: "--font-abril",
});

export const metadata: Metadata = {
  title: "RePattern",
  description: "An educational application about deceptive patterns",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body
        className={`${geistSans.variable} ${geistMono.variable} ${abril.variable}`}
        style={{
          display: "grid",
          gridTemplateRows: "auto 1fr auto",
          minHeight: "100vh",
          margin: 0,
        }}
      >
        <AppRouterCacheProvider>
          <MuiThemeProvider>
            <NavBar />
            {children}
            <Footer />
          </MuiThemeProvider>
        </AppRouterCacheProvider>
      </body>
    </html>
  );
}
