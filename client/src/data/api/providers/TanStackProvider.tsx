"use client";

import { ApiError } from "@/data/commonTypes";
import { getPageUrl, UNAUTHORIZED } from "@/data/constants";
import { MutationCache, QueryCache, QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { useRouter } from "next/navigation";
import { ReactNode, useState } from "react";

const TanStackProvider = ({ children }: { children: ReactNode }) => {
  const router = useRouter();

  const [queryClient] = useState(
    () =>
      new QueryClient({
        queryCache: new QueryCache({
          onError: (error, query) => {
            if (error instanceof ApiError && error.code === UNAUTHORIZED && !query.meta?.skipUnauthorizedRedirect) {
              router.push(getPageUrl.login());
            }
          },
        }),

        mutationCache: new MutationCache({
          onError: (error, _variables, _context, mutation) => {
            if (error instanceof ApiError && error.code === UNAUTHORIZED && !mutation.meta?.skipUnauthorizedRedirect) {
              router.push(getPageUrl.login());
            }
          },
        }),

        defaultOptions: {
          queries: {
            retry: false,
          },
          mutations: {
            retry: false,
          },
        },
      }),
  );

  return <QueryClientProvider client={queryClient}>{children}</QueryClientProvider>;
};

export default TanStackProvider;
