export const getPageUrl = {
    landing: () => '/',
    login: () => '/login',
    resetPassword: () => '/reset-password',
    register: () => '/register',
    profile: () => "/profile",
    learnDashboard: () => '/learn-dashboard',
    usageInstructions: () => '/instructions',
    attributions: () => '/attributions'
}

export const BACKEND_BASE_URL = "https://localhost:5000"
export const API_BASE_URL = `${BACKEND_BASE_URL}/api`
export const UNAUTHORIZED = "UNAUTHORIZED"
export const INTERACTIVE_WEBSITE_URL = "https://ba-usability-study-website-repatter.vercel.app";