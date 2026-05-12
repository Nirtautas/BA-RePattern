import ResetPasswordPage from "@/components/Pages/resetPasswordPage/resetPasswordPage";
import { connection } from "next/server";

const Page = async () => {
  await connection();
  return <ResetPasswordPage />;
};

export default Page;
