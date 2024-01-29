/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: [
      "light",
      "dark",
      "cupcake",
      {
        lyricsDark: {
          primary: "#a2f263",
          secondary: "#636363",
          accent: "#ff8862",
          neutral: "#ebebf5",
          info: "#283135",
          success: "#a2f263",
          warning: "#ffffff",
          error: "#ff675f",
          "base-100": "#1e2528",
          "base-300": "#273034",
        },
      },
    ],
  },
};
