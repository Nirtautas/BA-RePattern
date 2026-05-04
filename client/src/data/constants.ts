export const getPageUrl = {
    landing: () => '/',
    login: () => '/login',
    forgotPassword: () => '/forgot-password',
    resetPassword: () => '/reset-password',
    register: () => '/register',
    profile: () => "/profile",
    learnDashboard: () => '/learn-dashboard',
    usageInstructions: () => '/instructions',
    attributions: () => '/attributions',
    learnTheory: (uniquePathFragment: string) => `${getPageUrl.learnDashboard()}/${uniquePathFragment}/theory`,
    learnInteractive: (uniquePathFragment: string) => `${getPageUrl.learnDashboard()}/${uniquePathFragment}`,
    interactivePage: (uniquePathFragment: string) => `${INTERACTIVE_WEBSITE_URL}/${uniquePathFragment}/reset`,
};

export const BACKEND_BASE_URL = "https://localhost:5000"
export const API_BASE_URL = `${BACKEND_BASE_URL}/api`
export const UNAUTHORIZED = "UNAUTHORIZED"
export const INTERACTIVE_WEBSITE_URL = "http://localhost:3000/en";
//https://ba-usability-study-website-repatter.vercel.app