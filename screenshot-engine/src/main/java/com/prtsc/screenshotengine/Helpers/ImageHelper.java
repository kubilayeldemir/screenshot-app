package com.prtsc.screenshotengine.Helpers;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import ru.yandex.qatools.ashot.Screenshot;

import javax.imageio.ImageIO;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Base64;
import java.util.Date;

public class ImageHelper {
    static Logger log = LoggerFactory.getLogger(ImageHelper.class);

    private ImageHelper() {
    }

    public static void saveImageToFile(Screenshot screenshot) {
        try {
            ImageIO.write(screenshot.getImage(), "PNG", new File("./Screenshots/" + new SimpleDateFormat("yyyyMMddHHmmss'.txt'").format(new Date()) + ".png"));
        } catch (Exception e) {
            log.error("saveImageToFile Error: {} ", e.getMessage());
        }
    }

    public static String transformImageToBase64String(Screenshot screenshot) {
        final ByteArrayOutputStream os = new ByteArrayOutputStream();
        try {
            ImageIO.write(screenshot.getImage(), "PNG", os);
        } catch (Exception e) {
            log.error("transformImageToBase64String Error: {} ", e.getMessage());
        }
        return Base64.getEncoder().encodeToString(os.toByteArray());
    }
}
