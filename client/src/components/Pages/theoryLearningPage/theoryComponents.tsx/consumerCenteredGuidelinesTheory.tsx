import { DividerDark, TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { Box, List, ListItem, ListItemText, Stack } from "@mui/material";

const guidelineData = [
  {
    title: "CEG1. Being in control",
    items: [
      "I am forced to do actions (e.g. register an account), which should be unnecessary or unrelated to my main task.",
      "I don’t know how or its harder to exit / cancel certain situations than I thought (e.g. subscriptions).",
    ],
  },
  {
    title: "CEG2. Having time and effort respected",
    items: [
      "I feel rushed (e.g. countdown) to complete certain tasks (e.g. buy a product).",
      "The time and effort (e.g. entering shipping details) I put into the website seem to be exploited or disrespected (e.g. the full price of my order is revealed only after entering payment information).",
    ],
  },
  {
    title: "CEG3. Being communicated with respectfully",
    items: [
      "I am being repeatedly nagged (e.g. relentless pop-ups) to do or select certain options (e.g. subscribe to the newsletter).",
      "I feel unpleasant or negative emotions (e.g. shame, guilt) when selecting or not selecting given choices (e.g. accepting marketing communications).",
    ],
  },
  {
    title: "CEG4. Having privacy respected",
    items: ["I feel like I was mislead or forced to disclose more information about myself (e.g. name, email, etc.) than I needed to complete my main task."],
  },
  {
    title: "CEG5. Being informed of changes in a timely manner",
    items: [
      "I am not informed about or presented with important changes (e.g. added extras) in a timely manner (e.g. only at the end of the checkout process).",
      "I am not fully informed about how my actions (e.g. checking a checkbox) may influence consequences (e.g. starting a recurring subscription).",
    ],
  },
  {
    title: "CEG6. Being provided with required information",
    items: [
      "I lack, can’t or hardly can find information (e.g. terms of cancellation) in order to make informed decisions (e.g. cancelling a recurring subscription).",
      "I feel like given information (e.g. terms of cancellation) is presented to me in a dishonest way or hidden away.",
    ],
  },
  {
    title: "CEG7. Being provided with information clearly",
    items: ["The information I’m provided with (e.g. terms of cancellation) is unclear, hard to understand or confusing (e.g. uses ambiguous or technical wording, found in unexpected places)."],
  },
  {
    title: "CEG8. Being pointed to the right direction",
    items: [
      "I feel that less personally beneficial options are highlighted (e.g. subscription deal), preselected (e.g. using checkmarks) or defaulted to (e.g. adding an extra product to cart with amount set to 1 or more).",
      "I feel like I’m presented with redundant or distracting information.",
    ],
  },
];

type Props = {
  category: CategoryResponse;
};

const ConsumerCenteredGuidelinesTheory = () => {
  return (
    <Stack>
      <TheoryText sx={{ paddingBottom: 1, paddingTop: 1 }}>
        The main aim of consumer-centered guidelines (included below) is to educate you about deceptive patterns by providing a common list of signs, that they exibit. By familiriazing yourself with
        these guidelines, you may become more proficient in identifying deceptive or manipulative user interface elements, in addition to having an easier time completing further interactive
        exercises.
      </TheoryText>
      <DividerDark sx={{ marginBottom: 1 }} />
      {guidelineData.map((section) => (
        <Box key={section.title}>
          <TheoryText sx={{ fontWeight: "bold", textIndent: 0 }}>{section.title} –</TheoryText>

          <List
            sx={{
              paddingLeft: 6,
            }}
          >
            {section.items.map((item) => (
              <ListItem key={item} disablePadding>
                <ListItemText primary={<TheoryText sx={{ textAlign: "justify", textIndent: 0 }}>{item}</TheoryText>} />
              </ListItem>
            ))}
          </List>
        </Box>
      ))}
    </Stack>
  );
};

export default ConsumerCenteredGuidelinesTheory;
