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
    learnInteractive: (uniquePathFragment: string) => `${getPageUrl.learnDashboard()}/${uniquePathFragment}/interactive`,
    interactivePage: (uniquePathFragment: string) => `${INTERACTIVE_WEBSITE_URL}/${uniquePathFragment}/reset`,
    categoryTest: (categoryId: number) => `/tests/category/${categoryId}`,
    periodicTest: () => `/tests/periodic/`,
    testExecutionResult: (executionId: number) => `/tests/execution/${executionId}/result`,
};

export const BACKEND_BASE_URL = "https://localhost:5000"
export const API_BASE_URL = `${BACKEND_BASE_URL}/api`
export const BACKEND_IMAGES_URL = `${BACKEND_BASE_URL}/images`
export const BACKEND_PATTERN_EXAMPLE_IMAGES_URL = `${BACKEND_IMAGES_URL}/theory-images`
export const UNAUTHORIZED = "UNAUTHORIZED"
export const INTERACTIVE_WEBSITE_URL = "https://ba-usability-study-website-repatter.vercel.app";